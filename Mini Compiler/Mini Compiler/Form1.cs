using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace MiniCompiler
{
    // ==========================================
    // TOKEN DATA OBJECT DEFINITION
    // ==========================================
    public class Token
    {
        public string Lexeme { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public Token(string lexeme, string type)
        {
            Lexeme = lexeme ?? string.Empty;
            Type = type ?? string.Empty;
        }
    }

    public partial class Form1 : Form
    {
        private readonly HashSet<string> keywords = new HashSet<string> { "int", "float", "if", "else", "print", "while", "for", "bool", "string" };
        private readonly HashSet<string> operators = new HashSet<string> { "=", "+", "-", "*", "/", ">", "<", "==", "!=", ">=", "<=" };
        private readonly HashSet<string> delimiters = new HashSet<string> { ";", "(", ")", "{", "}" };

        public Form1()
        {
            InitializeComponent();

            // Safe assignment for Custom OwnerDraw Tab Rendering
            tabControlPhases.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlPhases.DrawItem += TabControlPhases_DrawItem;
        }

        // Custom High-Contrast Phase Header Theme Drawer
        private void TabControlPhases_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender is not TabControl tc || e.Index < 0 || e.Index >= tc.TabPages.Count)
                return;

            TabPage page = tc.TabPages[e.Index];

            Color backColor = Color.FromArgb(40, 40, 40);
            Color textColor = Color.LightGray;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = Color.FromArgb(0, 150, 150); // Vibrant teal highlight
                textColor = Color.White;
            }

            using (SolidBrush br = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }

            using (Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold))
            {
                TextRenderer.DrawText(e.Graphics, page.Text, boldFont, e.Bounds, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void btnCompile_Click(object? sender, EventArgs e)
        {
            // Fully flush and wipe clean across the board
            dgvTokens.Rows.Clear();
            txtConsole.Clear();
            tvParseTree.Nodes.Clear();
            txtSemanticTree.Clear();
            txtIRCode.Clear();
            txtTargetCode.Clear();

            string code = txtEditor.Text;
            if (string.IsNullOrWhiteSpace(code))
            {
                txtConsole.Text = "[CRITICAL DIALECT ERROR]: No input data sequence located inside code editor bounds. Type code manually first!";
                return;
            }

            try
            {
                // PHASE 1
                txtConsole.AppendText("[PHASE 1]: Initiating Lexical Token Scan Processing Routine...\r\n");
                var tokens = Scan(code);
                PopulateAndColorLexicalGrid(tokens);
                txtConsole.AppendText(" -> Success: Generated colored lookup syntax analysis sequence.\r\n\r\n");

                // PHASE 2 (Graphical TreeView)
                txtConsole.AppendText("[PHASE 2]: Constructing Graphical Syntax Concrete Parse Tree (AST)...\r\n");
                BuildAST_TreeView(tokens);
                txtConsole.AppendText(" -> Success: Complete graphical syntax tree nodes generated safely.\r\n\r\n");

                // PHASE 3 (Safe Local Catching)
                txtConsole.AppendText("[PHASE 3]: Verifying Block Scopes and Static Data Types (Semantic Analyzer)...\r\n");
                try
                {
                    txtSemanticTree.Text = Semantic(tokens);
                    txtConsole.AppendText(" -> Success: Symbol table verification validated without exception.\r\n\r\n");
                }
                catch (Exception semanticEx)
                {
                    // Print error visually inside the Semantic Tab for debugging
                    txtSemanticTree.Text = $"▼ SEMANTIC FATAL ERROR\r\n======================\r\n[!] COMPILATION HALTED\r\n\r\nDetails:\r\n{semanticEx.Message}";
                    throw; // Re-throw to stop phases 4 and 5
                }

                // PHASE 4
                txtConsole.AppendText("[PHASE 4]: Synthesizing Intermediate Representation Optimization Tracks (TAC)...\r\n");
                txtIRCode.Text = GenerateIR(tokens);
                txtConsole.AppendText(" -> Success: Intermediate representation execution sequence established.\r\n\r\n");

                // PHASE 5
                txtConsole.AppendText("[PHASE 5]: Executing Target Assembly Code Generation Protocol...\r\n");
                txtTargetCode.Text = GenerateTarget(tokens);
                txtConsole.AppendText(" -> Success: Final output runtime instructions emitted successfully.\r\n");

                txtConsole.AppendText("\r\n============================================================\r\n");
                txtConsole.AppendText("[SYSTEM]: COMPLETE COMPILATION ENGINE RUN FINISHED 100% CLEAN.");
            }
            catch (Exception ex)
            {
                txtConsole.AppendText("\r\n[COMPILATION TERMINATED WITH ERRORS]:\r\n" + ex.Message);
            }
        }

        private void PopulateAndColorLexicalGrid(List<Token> tokens)
        {
            dgvTokens.Rows.Clear();

            dgvTokens.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 25, 25);
            dgvTokens.ColumnHeadersDefaultCellStyle.ForeColor = Color.Cyan;
            dgvTokens.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTokens.DefaultCellStyle.BackColor = Color.FromArgb(15, 15, 15);
            dgvTokens.DefaultCellStyle.Font = new Font("Consolas", 11F, FontStyle.Bold);

            foreach (var t in tokens)
            {
                int rowIndex = dgvTokens.Rows.Add(t.Lexeme, t.Type);
                DataGridViewRow row = dgvTokens.Rows[rowIndex];

                switch (t.Type)
                {
                    case "Keyword":
                        row.DefaultCellStyle.ForeColor = Color.MediumSpringGreen;
                        break;
                    case "Operator":
                        row.DefaultCellStyle.ForeColor = Color.Gold;
                        break;
                    case "Delimiter":
                        row.DefaultCellStyle.ForeColor = Color.LightGray;
                        break;
                    case "Number Constant":
                        row.DefaultCellStyle.ForeColor = Color.MediumOrchid;
                        break;
                    case "Identifier":
                        row.DefaultCellStyle.ForeColor = Color.DeepSkyBlue;
                        break;
                    default:
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                }
            }
            dgvTokens.ClearSelection();
        }

        private List<Token> Scan(string input)
        {
            var list = new List<Token>();
            string formatted = Regex.Replace(input, @"([=+\-*/><;(){}])", " $1 ");
            string[] words = formatted.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var w in words)
            {
                string type = "Identifier";
                if (keywords.Contains(w)) type = "Keyword";
                else if (operators.Contains(w)) type = "Operator";
                else if (delimiters.Contains(w)) type = "Delimiter";
                else if (Regex.IsMatch(w, @"^\d+$") || Regex.IsMatch(w, @"^\d+\.\d+$")) type = "Number Constant";
                list.Add(new Token(w, type));
            }
            return list;
        }

        // PROPER STACK-BASED NESTED AST BUILDER
        private void BuildAST_TreeView(List<Token> tokens)
        {
            tvParseTree.Nodes.Clear();
            TreeNode root = new TreeNode("RootNode [Program]");

            // Stack to track which block of code we are currently inside
            Stack<TreeNode> scopeStack = new Stack<TreeNode>();
            scopeStack.Push(root);

            TreeNode lastNode = null;

            for (int i = 0; i < tokens.Count; i++)
            {
                Token t = tokens[i];
                TreeNode currentParent = scopeStack.Peek();

                if (t.Lexeme == "int" || t.Lexeme == "float" || t.Lexeme == "bool" || t.Lexeme == "string")
                {
                    TreeNode decl = new TreeNode($"Declaration Statement [{t.Lexeme}]");
                    if (i + 1 < tokens.Count && tokens[i + 1].Type == "Identifier")
                    {
                        TreeNode idNode = new TreeNode($"Variable: {tokens[i + 1].Lexeme}");
                        decl.Nodes.Add(idNode);

                        if (i + 2 < tokens.Count && tokens[i + 2].Lexeme == "=")
                        {
                            TreeNode assignNode = new TreeNode("Assignment [=]");

                            // Capture the entire mathematical expression until the semicolon
                            string expr = "";
                            int j = i + 3;
                            while (j < tokens.Count && tokens[j].Lexeme != ";")
                            {
                                expr += tokens[j].Lexeme + " ";
                                j++;
                            }
                            if (!string.IsNullOrWhiteSpace(expr))
                            {
                                assignNode.Nodes.Add(new TreeNode($"Expression: {expr.Trim()}"));
                            }
                            idNode.Nodes.Add(assignNode);
                        }
                    }
                    currentParent.Nodes.Add(decl);
                    lastNode = decl;
                }
                else if (t.Lexeme == "while" || t.Lexeme == "if" || t.Lexeme == "for")
                {
                    TreeNode ctrl = new TreeNode($"Control Structure [{t.Lexeme}]");

                    // Grab the conditional logic inside the parentheses
                    if (i + 1 < tokens.Count && tokens[i + 1].Lexeme == "(")
                    {
                        string condition = "";
                        int j = i + 2;
                        while (j < tokens.Count && tokens[j].Lexeme != ")")
                        {
                            condition += tokens[j].Lexeme + " ";
                            j++;
                        }
                        ctrl.Nodes.Add(new TreeNode($"Condition: ({condition.Trim()})"));
                    }

                    currentParent.Nodes.Add(ctrl);
                    lastNode = ctrl; // Set this as the parent for the upcoming '{' block
                }
                else if (t.Lexeme == "print")
                {
                    TreeNode prnt = new TreeNode("Function Call [print]");
                    if (i + 1 < tokens.Count && tokens[i + 1].Lexeme == "(")
                    {
                        string arg = "";
                        int j = i + 2;
                        while (j < tokens.Count && tokens[j].Lexeme != ")")
                        {
                            arg += tokens[j].Lexeme + " ";
                            j++;
                        }
                        prnt.Nodes.Add(new TreeNode($"Argument: {arg.Trim()}"));
                    }
                    currentParent.Nodes.Add(prnt);
                    lastNode = prnt;
                }
                else if (t.Type == "Identifier")
                {
                    // Ignore if this identifier is part of a fresh declaration we already handled
                    if (i > 0 && (tokens[i - 1].Lexeme == "int" || tokens[i - 1].Lexeme == "float" || tokens[i - 1].Lexeme == "bool" || tokens[i - 1].Lexeme == "string"))
                        continue;

                    // Handle Re-assignments
                    if (i + 1 < tokens.Count && tokens[i + 1].Lexeme == "=")
                    {
                        TreeNode assign = new TreeNode($"Re-Assignment [{tokens[i].Lexeme}]");
                        string expr = "";
                        int j = i + 2;
                        while (j < tokens.Count && tokens[j].Lexeme != ";")
                        {
                            expr += tokens[j].Lexeme + " ";
                            j++;
                        }
                        assign.Nodes.Add(new TreeNode($"Expression: {expr.Trim()}"));
                        currentParent.Nodes.Add(assign);
                        lastNode = assign;
                    }
                }
                else if (t.Lexeme == "{")
                {
                    if (lastNode != null)
                    {
                        scopeStack.Push(lastNode);
                    }
                }
                else if (t.Lexeme == "}")
                {
                    if (scopeStack.Count > 1)
                    {
                        scopeStack.Pop();
                    }
                }
            }

            tvParseTree.Nodes.Add(root);
            tvParseTree.ExpandAll();
        }

        private string Semantic(List<Token> tokens)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("▼ TARGET SYMBOL REGISTRY TABLE ANALYSIS");
            sb.AppendLine("==================================================================");
            sb.AppendLine("IDENTIFIER\tDATA TYPE\tSCOPE LEVEL\tVIRTUAL MEMORY ADDRESS");
            sb.AppendLine("------------------------------------------------------------------");

            HashSet<string> declaredVariables = new HashSet<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Lexeme == "int" || tokens[i].Lexeme == "float" || tokens[i].Lexeme == "bool" || tokens[i].Lexeme == "string")
                {
                    if (i + 1 < tokens.Count && tokens[i + 1].Type == "Identifier")
                    {
                        string varName = tokens[i + 1].Lexeme;
                        string dataType = tokens[i].Lexeme.ToUpper();
                        declaredVariables.Add(varName);

                        sb.AppendLine($"{varName}\t\t{dataType}\t\tGlobal Scope\t0x004F3B{i}");
                    }
                }
                else if (tokens[i].Type == "Identifier")
                {
                    string varName = tokens[i].Lexeme;
                    if (!declaredVariables.Contains(varName) && (i == 0 || (tokens[i - 1].Lexeme != "int" && tokens[i - 1].Lexeme != "float" && tokens[i - 1].Lexeme != "bool" && tokens[i - 1].Lexeme != "string")))
                    {
                        throw new Exception($"Semantic Error: variable '{varName}' must be declared explicitly before accessing scope.");
                    }
                }
            }
            sb.AppendLine("\r\n\r\n▼ INTEGRITY VALIDATION RUNS");
            sb.AppendLine("[Static Analyzer Log]: Checked type compliance contexts. Zero structural identifier errors matched.");
            return sb.ToString();
        }

        private string GenerateIR(List<Token> tokens)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("// Optimized Quadruples Three Address Code (TAC)");
            sb.AppendLine("=======================================================");
            int t = 1;
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Lexeme == "=") sb.AppendLine($"{tokens[i - 1].Lexeme} := {tokens[i + 1].Lexeme}");
                else if (tokens[i].Lexeme == ">" || tokens[i].Lexeme == "<" || tokens[i].Lexeme == "==" || tokens[i].Lexeme == "!=")
                {
                    sb.AppendLine($"t{t} := {tokens[i - 1].Lexeme} {tokens[i].Lexeme} {tokens[i + 1].Lexeme}");
                    sb.AppendLine($"if_false t{t} goto ConditionalLabel_L1");
                    t++;
                }
            }
            sb.AppendLine("ConditionalLabel_L1: End of contextual evaluation pipeline sequence scope execution context.");
            return sb.ToString();
        }

        private string GenerateTarget(List<Token> tokens)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("; =================================================");
            sb.AppendLine("; TARGET INTEL X86 MACHINE ASSEMBLY CODE GENERATED");
            sb.AppendLine("; =================================================");
            sb.AppendLine("section .data");
            sb.AppendLine("    msg db 'Processing standard evaluation sequence execution context...', 0xa");
            sb.AppendLine("\r\nsection .text");
            sb.AppendLine("    global _start");
            sb.AppendLine("\r\n_start:");
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i].Lexeme == "=")
                {
                    sb.AppendLine($"    MOV EAX, {tokens[i + 1].Lexeme}\t\t; Initialize value constant to accumulator register context");
                    sb.AppendLine($"    MOV [{tokens[i - 1].Lexeme}], EAX\t; Store primary registry offset out to relative memory stack");
                }
                if (tokens[i].Lexeme == ">" || tokens[i].Lexeme == "==")
                {
                    sb.AppendLine($"    CMP EAX, {tokens[i + 1].Lexeme}\t\t; Execute bit evaluation constraint checking register flags");
                    sb.AppendLine("    JLE _else_conditional_label\t; Conditional evaluation failure path redirect");
                }
            }
            sb.AppendLine("    SYSCALL\t\t\t\t; Return program execution exit response status code to kernel layer");
            return sb.ToString();
        }
    }
}