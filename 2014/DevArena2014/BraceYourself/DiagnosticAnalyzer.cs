using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;

namespace BraceYourself
{
    // TODO: Consider implementing other interfaces that implement IDiagnosticAnalyzer instead of or in addition to ISymbolAnalyzer

    [DiagnosticAnalyzer]
    [ExportDiagnosticAnalyzer(DiagnosticId, LanguageNames.CSharp)]
        public class DiagnosticAnalyzer : ISyntaxNodeAnalyzer<SyntaxKind>
    {
        internal const string DiagnosticId = "BraceChecker";
        internal const string Description = "Single embedded statements must be surrounded with braces.";
        internal const string MessageFormat = "'{0}' requires braces";
        internal const string Category = "Style";

        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Description, MessageFormat, Category, DiagnosticSeverity.Warning);

        public ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public ImmutableArray<SymbolKind> SymbolKindsOfInterest { get { return ImmutableArray.Create(SymbolKind.NamedType); } }
        public void AnalyzeNode(SyntaxNode node, SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
        {
            var ifstatement = node as IfStatementSyntax;
            if (ifstatement != null &&
                ifstatement.Statement != null &&
                !ifstatement.Statement.IsKind(SyntaxKind.Block))
            {
                addDiagnostic(Diagnostic.Create(Rule, ifstatement.IfKeyword.GetLocation(), "if statements"));
            }

            var elseClause = node as ElseClauseSyntax;
            if (elseClause != null &&
                elseClause.Statement != null &&
                !elseClause.Statement.IsKind(SyntaxKind.Block) &&
                !elseClause.Statement.IsKind(SyntaxKind.IfStatement))
            {
                addDiagnostic(Diagnostic.Create(Rule, elseClause.ElseKeyword.GetLocation(), "if statements"));
            }
        }

        public ImmutableArray<SyntaxKind> SyntaxKindsOfInterest
        {
            get
            {
                return ImmutableArray.Create(SyntaxKind.IfStatement, SyntaxKind.ElseClause);
            }
        }
    }
}
