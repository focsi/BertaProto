﻿angular.module('IgenyApp', [])
    .controller('IgenyCtrl', function ($scope, $http) {
        console.log("Next igenyCtrl");
        $scope.nextIgeny = function () {
            console.log("Next igény");

            $http.get("/api/igeny").success(function (data, status, headers, config) {
                console.log(data.megnevezes );
                $scope.ID = data.id;
                $scope.Megnevezes = data.megnevezes;
                $scope.Leiras = data.leiras;
                $scope.Objektum = data.objektum;
            }).error(function (data, status, headers, config) {
                console.log( "Hiba: " + data );
            });
        };
    });

