using System;
using Nethermind.Blockchain.Processing;
using Nethermind.Core;
using Nethermind.Logging;
using Nethermind.Pipeline;

#nullable enable
namespace Nethermind.Dsl.Pipeline.Sources
{
    public class BlocksSource<TOut> : IPipelineElement<TOut> where TOut : Block
    {
        private readonly IBlockProcessor _blockProcessor;

        public BlocksSource(IBlockProcessor blockProcessor)
        {
            _blockProcessor = blockProcessor;
            try
            {
                _blockProcessor.BlockProcessed += OnBlockProcessed;
            }
            catch (Exception e)
            {
                // ignored for now, will add logger later
            }
        }

        public Action<TOut>? Emit { private get; set; }

        private void OnBlockProcessed(object? sender, BlockProcessedEventArgs args)
        {
            Emit?.Invoke((TOut) args.Block);
        }
    }
}