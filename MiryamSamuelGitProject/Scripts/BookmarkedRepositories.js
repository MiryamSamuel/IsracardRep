angular.module('myApp', [])
    .controller('bookmarkedRepositoryController', function ($scope, $http) {
       




        $scope.init = function () {
            $http.get('/Home/GetAllBookmarkedRepositories').then(function success(response) {
                $scope.bookmarkedRepositories = response.data.bookmarkedRepos;
            }, function error(response) {

            });
        }

        $scope.init();
     

    });