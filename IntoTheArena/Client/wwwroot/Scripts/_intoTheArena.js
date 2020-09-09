
var jsInterop = jsInterop || {};
var _selectedFighterId = '';
var _playerFighters;


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
        var unityInstance = UnityLoader.instantiate("unityContainer", "webGl/Build/webGl.json", { onProgress: UnityProgress });
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

