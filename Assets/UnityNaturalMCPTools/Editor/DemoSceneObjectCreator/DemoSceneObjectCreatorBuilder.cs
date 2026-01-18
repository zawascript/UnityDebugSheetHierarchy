using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.Server;
using UnityEngine;
using UnityNaturalMCP.Editor;

namespace UnityDebugSheetHierarchy.Editor.MCP
{
    [CreateAssetMenu(
        fileName = "DemoSceneObjectCreatorBuilder",
        menuName = "UnityNaturalMCP/Demo Scene Object Creator Builder")]
    public class DemoSceneObjectCreatorBuilder : McpBuilderScriptableObject
    {
        public override void Build(IMcpServerBuilder builder)
        {
            builder.WithTools<DemoSceneObjectCreator>();
        }
    }
}
