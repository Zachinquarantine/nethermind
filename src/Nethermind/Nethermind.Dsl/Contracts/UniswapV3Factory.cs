//  Copyright (c) 2021 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
// 

using Nethermind.Abi;
using Nethermind.Core;
using Nethermind.Facade;

namespace Nethermind.Dsl.Contracts
{
    public class UniswapV3Factory : BlockchainBridgeContract
    {
        private IConstantContract ConstantContract { get; } 
        
        public UniswapV3Factory(Address contractAddress, IBlockchainBridge blockchainBridge) : base(contractAddress)
        {
            ContractAddress = contractAddress;
            ConstantContract = GetConstant(blockchainBridge);
        }

        public Address getPool(BlockHeader header, Address tokenA, Address tokenB, uint fee)
        {
            return ConstantContract.Call<Address>(header, nameof(getPool), Address.Zero, tokenA, tokenB, fee);
        }  
    }
}