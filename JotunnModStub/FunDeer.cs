// JotunnModStub
// a Valheim mod skeleton using Jötunn
// 
// File:    JotunnModStub.cs
// Project: JotunnModStub

using BepInEx;
using UnityEngine;
using BepInEx.Configuration;
using Jotunn.Utils;
using Jotunn.Managers;
using Jotunn.Configs;
using System;

namespace FunDeer
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class FunDeer : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.fundeer";
        public const string PluginName = "FunDeer";
        public const string PluginVersion = "0.0.1";
        private AssetBundle assetBundle;

        private void Awake()
        {
            loadassets();
            ItemManager.OnVanillaItemsAvailable += loadenemy;
            LocalizationManager.Instance.AddLocalization(new LocalizationConfig("English")
            {
                Translations = {
                                {"enemy_fundeer","Fun Deer"},
                                {"enemy_fundeera","Fun Deer with Antlers"},
                                {"enemy_betterboar","Better Boar" }
                }
            });
        }

        private void loadassets()
        {
            assetBundle = AssetUtils.LoadAssetBundleFromResources("gimmepetz",typeof(FunDeer).Assembly);
        }


        private void loadenemy()
        {
            try
            {

                var fab = assetBundle.LoadAsset<GameObject>("FunDeer");
                var fab1 = assetBundle.LoadAsset<GameObject>("FunDeerA");
                var fab2 = assetBundle.LoadAsset<GameObject>("BetterBoar");
              

                Jotunn.Logger.LogMessage("Character drops added....for RRR I guess?");
                PrefabManager.Instance.AddPrefab(fab);
                PrefabManager.Instance.AddPrefab(fab1);
                PrefabManager.Instance.AddPrefab(fab2);

            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"Error while adding cloned item: {ex.Message}");
            }
            finally
            {
                Jotunn.Logger.LogInfo("Casting Magik into ObjectDB");
                ItemManager.OnVanillaItemsAvailable -= loadenemy;
            }
        }


    }
}

//  var CharDrop = fab.AddComponent<CharacterDrop>();
//  CharDrop.m_dropsEnabled = true;
