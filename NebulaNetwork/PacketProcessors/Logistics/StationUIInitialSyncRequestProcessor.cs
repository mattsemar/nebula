﻿using NebulaAPI;
using NebulaModel.Logger;
using NebulaModel.Networking;
using NebulaModel.Packets;
using NebulaModel.Packets.Logistics;

/*
 * When a client opens a stations UI we sync the complete state of settings and storage.
 * After that he will receive live updates while the UI is opened.
 */
namespace NebulaNetwork.PacketProcessors.Logistics
{
    [RegisterPacketProcessor]
    public class StationUIInitialSyncRequestProcessor : PacketProcessor<StationUIInitialSyncRequest>
    {
        public override void ProcessPacket(StationUIInitialSyncRequest packet, NebulaConnection conn)
        {
            if (IsClient)
            {
                return;
            }

            StationComponent stationComponent;
            StationComponent[] stationPool = GameMain.data.galaxy?.PlanetById(packet.PlanetId)?.factory?.transport?.stationPool;

            stationComponent = stationPool?[packet.StationId];

            if (stationComponent == null)
            {
                Log.Error($"StationUIInitialSyncRequestProcessor: Unable to find requested station on planet {packet.PlanetId} with id {packet.StationId} and gid {packet.StationGId}");
                return;
            }

            StationStore[] storage = stationComponent.storage;

            int[] itemId = new int[storage.Length];
            int[] itemCountMax = new int[storage.Length];
            int[] itemCount = new int[storage.Length];
            int[] itemInc = new int[storage.Length];
            int[] localLogic = new int[storage.Length];
            int[] remoteLogic = new int[storage.Length];
            int[] remoteOrder = new int[storage.Length];

            for (int i = 0; i < stationComponent.storage.Length; i++)
            {
                itemId[i] = storage[i].itemId;
                itemCountMax[i] = storage[i].max;
                itemCount[i] = storage[i].count;
                itemInc[i] = storage[i].inc;
                localLogic[i] = (int)storage[i].localLogic;
                remoteLogic[i] = (int)storage[i].remoteLogic;
                remoteOrder[i] = storage[i].remoteOrder;
            }

            conn.SendPacket(new StationUIInitialSync(
                packet.PlanetId,
                packet.StationId,
                packet.StationGId,
                stationComponent.tripRangeDrones,
                stationComponent.tripRangeShips,
                stationComponent.deliveryDrones,
                stationComponent.deliveryShips,
                stationComponent.warpEnableDist,
                stationComponent.warperNecessary,
                stationComponent.includeOrbitCollector,
                stationComponent.energy,
                stationComponent.energyPerTick,
                stationComponent.pilerCount,
                itemId,
                itemCountMax,
                itemCount,
                itemInc,
                localLogic,
                remoteLogic,
                remoteOrder
            ));
        }
    }
}
