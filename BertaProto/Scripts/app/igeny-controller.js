var igenyModule= angular.module('IgenyApp', []);


igenyModule.controller('listCtrl', function ($scope, $http) {
    console.log("Next listCtrl");
    $scope.nextIgeny = function () {
        console.log("All igény");

        $http.get("/api/igenyek").success(function (data, status, headers, config) {
            console.log(data );
            $scope.igenyek = data;
        }).error(function (data, status, headers, config) {
            console.log( "Hiba: " + data );
        });
    };
});

igenyModule.controller("formController", function ($scope, $http) {

    console.log("formController Init");

    $scope.processForm = function () {
        console.log("beírt érték" + $scope.igeny.id);

        $http.get("/api/igenyek/" + $scope.igeny.id ).success(function (data, status, headers, config) {
            console.log(data.megnevezes);
            $scope.Megnevezes = data.megnevezes;
            $scope.Leiras = data.leiras;
            $scope.Objektum = data.objektum;
        }).error(function (data, status, headers, config) {
            console.log("Hiba: " + data);
        });

    };
});
