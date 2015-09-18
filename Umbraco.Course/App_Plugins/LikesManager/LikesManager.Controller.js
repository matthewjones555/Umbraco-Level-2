angular.module("umbraco").controller("Level2.LikesManagerController",

    function ($scope, $http, entityResource, editorState, likesService) {
        
        var currentNodeId = editorState.current.id;
        console.log("Current node Id " + currentNodeId);

        $scope.load = function () {
            likesService.getAll(currentNodeId).then(
                function (response) {
                    var likes = response.data;
                    $scope.likes = likes;
                    $scope.model.value = likes.length;

                    angular.forEach(likes, function (like) {
                        entityResource.getById(like.ChildId, "Member").then(function (member) {
                            //add the member information to the like object
                            like.member = member;
                        });
                    });
                }
            );
        };

        $scope.delete = function(like) {
            likesService.delete(like.Id).then(function () {
                $scope.load();
            });
        };

        $scope.load();
    }
);