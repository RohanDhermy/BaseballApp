(function () {
    'use strict';

    angular.module(Baseball).controller("playerController", PlayerController);

    PlayerController.$inject = ["$scope", "playerService", "$uibModal", "$sce"];

    function PlayerController($scope, playerService, $uibModal, $sce)
    {
        var vm = this; 
        vm.teams = []; 
        vm.players = [];
        vm.$onInit = _init; 
        vm.add = _add; 
        vm.delete = _delete; 
        vm.news = []; 
        vm.selectedTeam; 
        vm.getNews = _getNews; 

        function _init() {
            _loadTeams(); 
            _loadPlayers(); 
            _getNews();
        }

        function _getNews() {
            console.log("get news called");
            playerService.GetNews(vm.selectedTeam)
                .then(function (data) {
                    console.log(data);
                    for (var i = 0; i < data.length; i++){
                        vm.news[i] = $sce.trustAsHtml(data[i]);
                    }
                })
                .catch(function (err) {
                    console.log(err);
                })
        }

        function _loadTeams() {
            playerService.GetTeams()
                .then(function (data) {
                    vm.teams = data; 
                    console.log(vm.teams);
                })
                .catch(function (err) {
                    console.log(err);
                })
        }

        function _loadPlayers() {
            playerService.GetAll()
                .then(function (data) {
                    vm.players = data;
                    console.log(vm.players);
                })
                .catch(function (err) {
                    console.log(err);
                })
            
        }

        function _add() {
            _openModal(null); 
        }

        function _add(player) {
            _openModal(player); 
        }

        function _delete(player) {
            playerService.Delete(player.Id)
                .then(function (data) {
                    console.log(data);
                    _init(); 
                })
                .catch(function (err) {
                    console.log(err);
                })
        }

        function _openModal(player) {
            var modalInstance = $uibModal.open({
                animation: true,
                component: "playerComponent",
                size: "md",
                resolve: {
                    item: function() {
                        return player;
                    }
                }
            });

            modalInstance.result.then(function () {
                _init();
            },function (){
            });
        }

    }
})(); 