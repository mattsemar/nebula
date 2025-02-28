﻿using NebulaAPI;
using NebulaModel.Networking;
using NebulaModel.Packets;
using NebulaModel.Packets.Factory;
using NebulaWorld;

namespace NebulaNetwork.PacketProcessors.Factory.Entity
{
    [RegisterPacketProcessor]
    internal class CreatePrebuildsRequestProcessor : PacketProcessor<CreatePrebuildsRequest>
    {
        public override void ProcessPacket(CreatePrebuildsRequest packet, NebulaConnection conn)
        {
            using (Multiplayer.Session.Factories.IsIncomingRequest.On())
            {
                // setting specifyPlanet here to avoid accessing a null object (see GPUInstancingManager activePlanet getter)
                PlanetData pData = GameMain.gpuiManager.specifyPlanet;

                GameMain.gpuiManager.specifyPlanet = GameMain.galaxy.PlanetById(packet.PlanetId);
                Multiplayer.Session.BuildTools.CreatePrebuildsRequest(packet);
                GameMain.gpuiManager.specifyPlanet = pData;
            }
        }
    }
}
