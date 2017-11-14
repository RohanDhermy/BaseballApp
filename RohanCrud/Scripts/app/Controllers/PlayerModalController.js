(function () {
    'use strict';

    angular.module(Baseball).component("playerComponent",
        {
            templateUrl: '/Scripts/Views/AddEditPlayer.html',
            bindings: {
                resolve: "<", 
                close: "&", 
                dismiss: "&"
            },
            controller: "playerModalController"
        });
})(); 

(function () {
    'use strict';

    angular.module(Baseball).controller("playerModalController", PlayerModalController);

    PlayerModalController.$inject = ["$scope", "playerService", "$uibModal"];

    function PlayerModalController($scope, playerService, $uibModal) {
        var vm = this;
        vm.$onInit = _init;
        vm.save = _save;
        vm.close = _close;
        vm.playerModel = {}; 
        vm.teams = []; 

        function _init() {
            if (vm.resolve.item) {
                vm.playerModel = vm.resolve.item;
                console.log("player model", vm.playerModel);
            }
            playerService.GetTeams()
                .then(function (data) {
                    vm.teams = data;
                })
                .catch(function (err) {
                    console.log(err);
                })
        }

        function _save() {
            if (vm.playerModel.Id) {
                console.log("Running edit");
                console.log(vm.playerModel);
                playerService.UpdateById(vm.playerModel)
                    .then(function (data) {
                        vm.close(); 
                    })
                    .catch(function (err) {
                        console.log(err);
                    })
            }
            else {
                playerService.Insert(vm.playerModel)
                    .then(function (data) {
                        vm.close(); 
                    })
                    .catch(function (err) {
                        console.log(err);
                    })
            }
        }

        function _close() {
            vm.close();
        }

    }
})(); 