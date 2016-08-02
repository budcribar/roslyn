using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace Microsoft.CodeAnalysis.CSharp
{
    internal sealed class BindStatementBinder : Binder
    {
        private readonly BindStatementSyntax _syntax;
        public List<ExpressionStatementSyntax> ExpressionStatement { get; set; } = new List<ExpressionStatementSyntax>();
        public BindStatementBinder(Binder enclosing, BindStatementSyntax syntax)
            : base(enclosing)
        {
            _syntax = syntax;
        }

        internal override BoundStatement BindBindStatementParts(DiagnosticBag diagnostics, Binder originalBinder)
        {
            BoundStatement boundBody = originalBinder.BindPossibleEmbeddedStatement(_syntax.Statement, diagnostics);
            bool hasErrors = false;
            var l1 = new List<string>();
            var l2 = new List<string>();

            foreach (var bindSection in _syntax.Bindings)
            {
                IdentifierNameSyntax i = bindSection.InterfaceIdentifier as IdentifierNameSyntax;
                IdentifierNameSyntax c = bindSection.ClassIdentifier as IdentifierNameSyntax;

               
                if (i == null)
                {
                    hasErrors = true;
                    Error(diagnostics, ErrorCode.ERR_InterfaceMemberNotFound, _syntax, bindSection.InterfaceIdentifier);

                }
                else l1.Add(i.Identifier.ValueText);
               
                if (c == null)
                {
                    hasErrors = true;
                    Error(diagnostics, ErrorCode.ERR_ClassTypeExpected, _syntax, bindSection.ClassIdentifier);

                }
                else l2.Add(c.Identifier.ValueText);
            }

            var x = l1.ToImmutableArray<string>();
            var y = l2.ToImmutableArray<string>();

            List<IOperation> bound = new List<IOperation>();

            foreach (var es in ExpressionStatement)
                bound.Add(originalBinder.BindExpressionStatement(es, diagnostics));

            return new BoundBindStatement(_syntax, x, y, bound.ToImmutableArray(), boundBody, hasErrors);

        }
    }
}
