(function () {
    'use strict';

    angular.module(Baseball).factory("playerService", PlayerService);

    PlayerService.$inject = ["$http", "$q"];

    function PlayerService($http, $q) {
        var srv = {
            GetAll: _getAll,
            GetById: _getById,
            Insert: _insert,
            UpdateById: _updateById,
            Delete: _delete,
            GetTeams: _getTeams,
            GetNews: _getNews
        }
        return srv;

        function _getAll() {
            return $http.get("/api/Player")
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }

        function _getById(id) {
            return $http.get("/api/Player/" + id)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }

        function _insert(player) {
            return $http.post("/api/Player", player)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }

        function _updateById(player) {
            return $http.put("/api/Player/" + player.Id, player)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }

        function _delete(id) {
            return $http.delete("/api/Player/" + id)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }

        function _getTeams() {
            return $http.get("/api/Player/Teams")
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }

        function _getNews(selectedTeam) {
            return $http.post("/api/Player/News/", selectedTeam)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                })
        }
    }
})();