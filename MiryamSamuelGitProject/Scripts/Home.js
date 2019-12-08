angular.module('myApp', [])
    .controller('indexController', function ($scope, $http) {
        $scope.textSearch = 'hghg';



        $scope.init = function () {
            alert("dfgd");
            $http.get('/Home/GetAllBookmarkedRepositories').then(function success(response) {
                $scope.bookmarkedRepositories = response.data.bookmarkedRepos;
            }, function error(response) {

            });
         }

        $scope.init();
        $scope.findRepositories = function () {
            $http.get("https://api.github.com/search/repositories?q=" + $scope.textSearch).then(function success(response) {
                $scope.repositories = response.data.items;
            }, function error(response) {

            });

        };


        $scope.bookmarkRepository = function (rep) {
            $http.post('/Home/SetBookmarkRepository', { repository: rep })
                .then(function (result) {
                    $scope.bookmarkedRepositories = result.data.bookmarkedRepos;
                });
        };


    });