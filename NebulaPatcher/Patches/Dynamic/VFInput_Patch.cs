using HarmonyLib;
using NebulaWorld;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NebulaPatcher.Patches.Dynamic
{
    [HarmonyPatch(typeof(VFInput))]
    internal class VFInput_Patch
    {
        [HarmonyPatch(nameof(VFInput._buildConfirm), MethodType.Getter)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Original Function Name")]
        public static bool _buildConfirm_Prefix(ref VFInput.InputValue __result)
        {
            if (Multiplayer.IsActive && Multiplayer.Session.Factories.IsIncomingRequest.Value)
            {
                __result = default;
                __result.onDown = true;
                return false;
            }
            return true;
        }

        /// <summary>
        /// This patch is to make it so that movement characters like WASD are not activated when we're typing in the chat window
        /// The game already does this for InputField components but it doesn't know about TMPInputField ones components
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(nameof(VFInput.UpdateGameStates))]
        public static void OnMaxChargePowerSliderValueChange_Postfix()
        {
            // VFInput.inputing is what we're trying to set (when chat is open) so if it's already true then we're done
            if (VFInput.onGUI == false || VFInput.inputing)
                return;
            GameObject selectedGameObject = EventSystem.current.currentSelectedGameObject;
            VFInput.inputing = selectedGameObject != null && selectedGameObject.GetComponent<TMP_InputField>() != null;
        }
    }
}
