using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustBuster2016;
using UnityEngine;

namespace GrassRemover
{
    public class GrassRemoverClass : RustBuster2016.API.RustBusterPlugin
    {
        public override string Name { get { return "GrassRemover"; } }
        public override string Author{get { return " by salva/juli (grass code by XandeTurf)"; }}
        public override Version Version{get { return new Version("1.1"); }}
        public static GrassRemoverClass Instance;
        public override void Initialize()
        {
            Instance = this;
            if (this.IsConnectedToAServer)
            {
                RustBuster2016.API.Hooks.OnRustBusterClientConsole += OnRustBusterClientConsole;
                Rust.Notice.Popup("", "(" + Name + ") grass.on true | grass.on false", 40);
                return;
            }
        }
        public override void DeInitialize()
        {
            RustBuster2016.API.Hooks.OnRustBusterClientConsole -= OnRustBusterClientConsole;
        }
        public void OnRustBusterClientConsole(string message)
        {
            if (message == "grass.on false")
            {
                Rust.Notice.Popup("", "Grass OFF", 30);
                Terrain.activeTerrain.heightmapPixelError = 110;
                Terrain.activeTerrain.detailObjectDistance = 0;
                Terrain.activeTerrain.treeDistance = 225;
                Terrain.activeTerrain.treeMaximumFullLODCount = 0;
            }
            else if (message == "grass.on true")
            {
                Rust.Notice.Popup("", "Grass ON", 30);
                Terrain.activeTerrain.heightmapPixelError = 30;
                Terrain.activeTerrain.detailObjectDistance = 134;
                Terrain.activeTerrain.treeDistance = 2000;
                Terrain.activeTerrain.treeMaximumFullLODCount = 60;
            }
        }
    }
}
