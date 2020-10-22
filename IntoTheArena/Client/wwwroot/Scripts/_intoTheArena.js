
var jsInterop = jsInterop || {};
var _selectedFighterId = '';
var _playerFighters;

var unityInstance;
//OpeningSequenceComplete

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
        //debugger;
        //alert(AnimationId); 
        //unityInstance.SendMessage("JavascriptHook", "DoAnimation",Params);
        unityInstance.SendMessage("JavascriptHook", "BlackSwing", "");
        unityInstance.SendMessage("JavascriptHook", "WhiteSwing");
        //unityInstance.SendMessage("JavascriptHook", "WhiteBlock", null);



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
        //unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json", { onProgress: UnityProgress });
        unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/Build.json", { onProgress: UnityProgress });

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

    ,
    whiteSwing: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteSwing");
    },

    whiteBlock: function (serializedBoolArray) {
        unityInstance.SendMessage("JavascriptHook", "WhiteBlock", serializedBoolArray);
    },

    whiteParry: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteParry");
    },

    whiteCounterParry: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteCounterParry");
    },

    whiteHeal: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteHeal");
    },

    whiteGashed: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteGashed");
    },

    whiteGroined: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteGroined");
    },

    whiteKick: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteKick");
    },

    whiteTwoHanded: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteTwoHanded");
    },

    whiteCelebrate: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteCelebrate");
    },

    whiteLaugh: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteLaugh");
    },

    whiteRun: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteRun");
    },

    whiteDie: function () {
        unityInstance.SendMessage("JavascriptHook", "WhiteDie");
    },

    blackSwing: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackSwing");
    },

    blackBlock: function (serializedBoolArray) {
        unityInstance.SendMessage("JavascriptHook", "BlackBlock", serializedBoolArray);
    },

    blackParry: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackParry");
    },

    blackCounterParry: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackCounterParry");
    },

    blackHeal: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackHeal");
    },

    blackGashed: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackGashed");
    },

    blackGroined: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackGroined");
    },

    blackKick: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackKick");
    },

    blackTwoHanded: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackTwoHanded");
    },

    blackCelebrate: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackCelebrate");
    },

    blackLaugh: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackLaugh");
    },

    blackRun: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackRun");
    },

    blackDie: function () {
        unityInstance.SendMessage("JavascriptHook", "BlackDie");
    }

    //blackBlock: function (serializedBoolArray) {
    //    unityInstance.SendMessage("JavascriptHook", "BlackBlock", serializedBoolArray);
    //},

};

