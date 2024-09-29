// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World.Blocks;
    using Eco.World;
    using System;
    using System.Linq;



    public class SteamFrontLoaderUtilities
    {
        // Mapping for custom stack sizes in vehicles by vehicle type as key
        // We can have different stack sizes in different vehicles with this
        public static Dictionary<Type, StackLimitTypeRestriction> AdvancedVehicleStackSizeMap = new Dictionary<Type, StackLimitTypeRestriction>();

        static SteamFrontLoaderUtilities() => CreateBlockStackSizeMaps();

        private static void CreateBlockStackSizeMaps()
        {
            var blockItems = Item.AllItems.Where(x => x is BlockItem).Cast<BlockItem>().ToList();

            // SteamFrontLoader
            var SteamFrontLoaderMap = new StackLimitTypeRestriction(true, 30);

            SteamFrontLoaderMap.AddListRestriction(blockItems.GetItemsByBlockAttribute<Diggable>(), 20);
            SteamFrontLoaderMap.AddListRestriction(blockItems.GetItemsByBlockAttribute<Minable>(), 0);


            // SteamFrontLoader
            AdvancedVehicleStackSizeMap.Add(typeof(SteamFrontLoaderObject), SteamFrontLoaderMap);
        }

        public static StackLimitTypeRestriction GetInventoryRestriction(object obj) => AdvancedVehicleStackSizeMap.GetOrDefault(obj.GetType());
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(VehicleToolComponent))]
    public class SteamFrontLoaderObject : PhysicsWorldObject
    {
        protected SteamFrontLoaderObject() { }
        public override LocString DisplayName                     { get { return Localizer.DoStr("Steam Front Loader"); } }

        static SteamFrontLoaderObject()
        {
            WorldObject.AddOccupancy<SteamFrontLoaderObject>(new List<BlockOccupancy>(0));
        }

        private static string[] fuelTagList = new string[]
        {
            "Burnable Fuel"
        };

        private Player Driver { get { return this.GetComponent<VehicleComponent>().Driver; } }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(25);
            this.GetComponent<AirPollutionComponent>().Initialize(0.5f);
            this.GetComponent<VehicleComponent>().Initialize(12, 1.2f, 1);
            this.GetComponent<VehicleToolComponent>().Initialize(4, 700000, new DirtItem(),
                100, 200, 0, SteamFrontLoaderUtilities.GetInventoryRestriction(this), toolOnMount:true);
        }
    }
}
