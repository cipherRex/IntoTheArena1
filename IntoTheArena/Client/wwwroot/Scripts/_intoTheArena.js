﻿
var jsInterop = jsInterop || {};
var _selectedFighterId = '';
var _playerFighters;

var unityInstance;


function onFighterSelected(data)
{
    _selectedFighterId = data.selectedData.value;

    $("#enterButton").removeClass("hiddenButton");
}

//jsInterop.initializeFightersDropDown = function (jsonString) {

//    _playerFighters = JSON.parse(jsonString);

//    $('#playerFighterSelect').ddslick({
//        data: _playerFighters,
//        selectText: "Select your warrior",
//        imagePosition: "right",
//        width: 290,
//        onSelected: function (data) {
//            onFighterSelected(data);
//        }
//    });
//};

window.intoTheArenaFunctions = {


    fooFunc: function () {
        //var unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json", { onProgress: UnityProgress });
        //debugger;
        var fooString = '{"functionName":"SlashSlash","player1Special":"false","player2Special":"false","player1Bleed":"1","player2Bleed":"2","player1Heal":"false","player2Heal":"false","player1Taunt":"false","player2Taunt":"false"}';

        unityInstance.SendMessage("JavascriptHook", "DoAnimation", fooString);
        //unityInstance.SendMessage("JavascriptHook", "FooAnimation", fooString);

        //unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json", { onProgress: UnityProgress });

    },

    //getSelectedFighterId: function () {
    triggerAnimation: function (Params) {

        console.log("triggerAnimation", Params);

        //alert(AnimationId); 
        unityInstance.SendMessage("JavascriptHook", "DoAnimation",Params);



        //var unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json");

        //switch (AnimationId)
        //{
        //    case 1:
        //        unityInstance.SendMessage("JavascriptHook", "SlashSlash", false, false, 1, 1, false, false);
        //        break;

        //    case 2:
        //        unityInstance.SendMessage("JavascriptHook", "SlashBock", false, false, true, false, false);
        //        break;

        //    default:
    //}

    // unityInstance.SendMessage

    /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SlashSlash(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        (eBloodLevel)UnityEngine.Random.Range(0, 4),
                        (eBloodLevel)UnityEngine.Random.Range(0, 4),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //SlashBock
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SlashBlock(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //SlashPower
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SlashPower1(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        (eBloodLevel)UnityEngine.Random.Range(0, 4),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //BlockSlash
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BlockSlash(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //BlockBlock
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            BlockBlock(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //BlockPower
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            BlockPower(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //PowerSlash
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PowerSlash2(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        (eBloodLevel)UnityEngine.Random.Range(0, 4)
                        );
        }

        //PowerBlock
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PowerBlock(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }

        //PowerPower
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PowerPower(Convert.ToBoolean(UnityEngine.Random.Range(0, 2)),
                        Convert.ToBoolean(UnityEngine.Random.Range(0, 2))
                        );
        }


     */

},

    getSelectedFighterId: function () {
        return _selectedFighterId;
    },

    startGame: function () {
        //var unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json", { onProgress: UnityProgress });
        unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json", { onProgress: UnityProgress });

    },

    initializeFightersDropDown: function (jsonString) {
        _playerFighters = JSON.parse(jsonString);

        $('#playerFighterSelect').ddslick({
            data: _playerFighters,
            selectText: "Select your warrior",
            imagePosition: "right",
            width: 290,
            onSelected: function (data) {
                onFighterSelected(data);
            }
        });;
    }

};

