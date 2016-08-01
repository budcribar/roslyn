using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal sealed partial class LocalRewriter
    {
        public override BoundNode VisitBindStatement(BoundBindStatement node)
        {
            // Generate code for: Bind.dictionary[typeof(ILogger)] = typeof(Logger);
          
            BoundStatement boundStatement = (BoundStatement)Visit(node.Binds);
            BoundStatement bodyStatement = (BoundStatement)Visit(node.Body);

            List<BoundStatement> list = new List<BoundStatement>();
            if (boundStatement != null) list.Add(boundStatement);
            list.Add(bodyStatement);

            return new BoundBlock(
                syntax: node.Syntax,
                locals: ImmutableArray<LocalSymbol>.Empty,
                localFunctions: ImmutableArray<LocalFunctionSymbol>.Empty,
                statements: list.ToImmutableArray());

        }
    }
}

