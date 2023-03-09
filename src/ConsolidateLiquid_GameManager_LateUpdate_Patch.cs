using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace ConsolidateLiquid
{
    [HarmonyPatch(typeof(GameManager), "LateUpdate")]
    public static class ConsolidateLiquid_GameManager_LateUpdate_Patch
    {
        public static void Postfix()
        {
            //Finish Here -Transfer test


#if DEBUG

            if (Input.GetKeyDown(KeyCode.Minus))
            {

                var allContainers = GetGroupedContainers();

                foreach (var liquidGroup in allContainers)
                {
                    foreach (var card in liquidGroup)
                    {

                    }
                }
            }

            //Randomize
            if (Input.GetKeyDown(KeyCode.U))
            {

                var random = new System.Random();

                var liquidContainers = GameManager.Instance.AllCards
                    .Where(x => x.Environment == GameManager.Instance.CurrentEnvironment
                        && x.ContainedLiquid != null)
                    .ToList();

                foreach (var container in liquidContainers)
                {
                    container.ContainedLiquid.CurrentLiquidQuantity =
                        (float)random.Next(1, (int)container.CardModel.MaxLiquidCapacity - 1);

                    container?.CardVisuals?.RefreshDurabilities();
                }
            
            }
#endif
            //Transfer
            if (Input.GetKeyDown(Plugin.ConsolidateHotKey.Value))
            {
                List<IGrouping<Tuple<CardData, CardData>, InGameCardBase>> liquidContainerGrouping = GetGroupedContainers();

               

                foreach (var group in liquidContainerGrouping)
                {
                    int maxLiquid = (int)group.Key.Item1.MaxLiquidCapacity;

                    int availableLiquid = group.Sum(x => (int)x.ContainedLiquid.CurrentLiquidQuantity);

                    foreach (var card in group)
                    {
                        //No more water.  Clear out the remaining containers.
                        if (availableLiquid == 0)
                        {
                            //The remaining containers should be empty.
                            GameManager.PerformAction(CardData.EmptyLiquidAction(card.ContainedLiquid.CardModel), card.ContainedLiquid, true);
                        }
                        else
                        {
                            InGameCardBase liquid = card.ContainedLiquid;

                            int liquidTaken = Math.Min(maxLiquid, availableLiquid);
                            availableLiquid -= liquidTaken;

                            liquid.CurrentLiquidQuantity = liquidTaken;
                            card?.CardVisuals?.RefreshDurabilities();
                        }
                    }
                }
            }
        }

        private static List<IGrouping<Tuple<CardData, CardData>, InGameCardBase>> GetGroupedContainers()
        {
            //Get containers that have liquid in the current environment
            var liquidContainers = GameManager.Instance.AllCards
                .Where(x => x.Environment == GameManager.Instance.CurrentEnvironment
                    && x.ContainedLiquid != null   
                    && x.CurrentContainer == null   //Ignore recipes 
                    && (int)x.ContainedLiquid.CurrentLiquidQuantity != (int)x.CardModel.MaxLiquidCapacity)  //not full
                .ToList();

            //Group containers with the same liquid.  
            List<IGrouping<Tuple<CardData, CardData>, InGameCardBase>> cardLiquidGrouping = liquidContainers
                .GroupBy(x => new Tuple<CardData, CardData>(x.CardModel, x.ContainedLiquid.CardModel))
                .Where(x => x.Count() > 1)
                .ToList();

            return cardLiquidGrouping;

        }
    }
}
