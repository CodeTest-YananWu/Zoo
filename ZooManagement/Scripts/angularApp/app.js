var app = angular.module('zooApp', ['ngRoute'])
.controller('MainCtrl', function ($scope, $route, $routeParams, $location) {
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
})
.controller('AnimalCtrl', function ($scope, $http, $location) {
    $http.get('api/Animals')
    .success(function (data) {
        $scope.Animals = data;
    })
    .error();

    $http.get('api/get/AnimalTypes')
    .success(function (data) {
        $scope.AnimalTypes = data;
    })
    .error();

    $http.get('api/get/AnimalGenders')
    .success(function (data) {
        $scope.AnimalGenders = data;
    })
    .error();

    $http.get('api/Zookeepers')
    .success(function (data) {
        $scope.Zookeepers = data;
    })
    .error();

    $scope.AddAnimal = function () {
        $scope.Error = null;

        var keeperInfo = $scope.ZookeeperName;
        var index = keeperInfo.search('-');
        var staffID = keeperInfo.substr(index+1, keeperInfo.length - index-1);
        for (var i = 0; i < $scope.Zookeepers.length; i++) {
            if (staffID === $scope.Zookeepers[i].StaffID)
                $scope.NewAnimal.Zookeeper = $scope.Zookeepers[i];
        }
        $scope.NewAnimal.AnimalID = null;
        $http.post('api/Animals', $scope.NewAnimal)
        .success(function (data) {
            $location.path("/Home/Success");
        })
        .error(function (data, status, headers, config) {
            //The only possibility is zookeeper not found, otherwise could be database error.
            $scope.Error = 'Request failed. Please make sure Zookeeper info is correct.';
        });
    };
})
.controller('ZookeeperCtrl', function ($scope, $http,$location) {
    $http.get('api/Zookeepers')
        .success(function (data) {
            $scope.Zookeepers = data;
        })
        .error(function () { });
    $scope.NewKeeper = {};
    $scope.NewKeeper.Id = -1;
    $scope.NewKeeper.StaffID = null;

    $scope.dobError = null;

    $scope.AddKeeper = function () {
        $scope.Error = null;
        $scope.dobError = null;
        $http.post('api/Zookeepers', $scope.NewKeeper)
        .success(function (data) {
            $location.path("/Home/Success");
        })
        .error(function (data, status, headers, config) {
            //The only possibility is validation error of DateOfBirth, otherwise could be database error.
            if (data.ModelState && data.ModelState['zookeeper.DateOfBirth']) {
                $scope.dobError = 'Invalid Date';
            }
            else {
                $scope.Error = 'Request failed';
            }
        });
    };
})
.config(function ($routeProvider, $locationProvider) {
    $routeProvider.
      when('/Home/Animals', {
          templateUrl: 'Home/Animals',
          controller: 'AnimalCtrl'
      }).
        when('/Home/AnimalsEdit', {
            templateUrl: 'Home/AnimalsEdit',
            controller: 'AnimalCtrl'
        }).
      when('/Home/Zookeepers', {
          templateUrl:'Home/ZooKeepers',
          controller: 'ZookeeperCtrl'
      }).
        when('/Home/ZookeepersEdit', {
            templateUrl: 'Home/ZookeepersEdit',
            controller: 'ZookeeperCtrl'
        }).
        when('/Home/Success', {
            templateUrl: 'Home/Success'
        }).
      otherwise({
          redirectTo: '/Home/Animals'
      });
    $locationProvider.html5Mode(true);
});
