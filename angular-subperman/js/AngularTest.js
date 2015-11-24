
var myMoudel = angular.module("myTestMOudel", []);
myMoudel.controller("MyCtrl1", ["$scope",
    function ($scope) {
        $scope.UserName = "这是一个警告！！！";
    }]);

var moudel = angular.module("myMoudel", []);
moudel.controller("myCtrl", ["$scope", function ($scope) {
    $scope.tt = "123";
}]);