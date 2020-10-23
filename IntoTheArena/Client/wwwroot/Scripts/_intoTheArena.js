
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


    getSelectedFighterId: function () {
        return _selectedFighterId;
    },

    startGame: function () {
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
    },

    whiteHealEffect: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "WhiteHealEffect", amt);
    },

    whiteBleedEffect: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "WhiteBleedEffect", amt);
    },

    blackHealEffect: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "BlackHealEffect", amt);
    },

    blackBleedEffect: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "BlackBleedEffect", amt);
    },



    setWhiteHPs: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "SetWhiteHPs", amt);
    },

    setBlackHPs: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "SetBlackHPs", amt);
    },

    setWhiteDmg: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "setWhiteDmg", amt);
    },

    setBlackDmg: function (amt) {
        unityInstance.SendMessage("JavascriptHook", "setBlackDmg", amt);
    },

    setSystemMsg: function (msg) {
        unityInstance.SendMessage("JavascriptHook", "setSystemMsg", msg);
    },

    hideHPLabels: function () {
        unityInstance.SendMessage("JavascriptHook", "hideHPLabels");
    }








};

