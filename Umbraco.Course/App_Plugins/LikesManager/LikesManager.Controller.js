angular.module("umbraco").controller("Level2.LikesManagerController",

    function ($scope, $http, entityResource, editorState) {
        
        var currentNodeId = editorState.current.id;
        console.log("Current node Id " + currentNodeId);

        $scope.load = function () {

            // perform loading here..

        };

        $scope.delete = function(like) {
           
        };

        $scope.load();
    }
);