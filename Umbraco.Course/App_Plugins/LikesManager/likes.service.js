angular.module("umbraco.services").factory("likesService", function ($http) {
    return {
        delete: function (id) {
            return $http.post("/umbraco/backoffice/API/LikesManager/PostDeleteById/" + id);
        },
        getAll: function (id) {
            return $http.get("/umbraco/backoffice/API/LikesManager/GetAll/" + id);
        }
    };
});