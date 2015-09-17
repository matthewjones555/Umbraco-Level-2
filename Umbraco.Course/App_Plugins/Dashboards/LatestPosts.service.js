    angular.module("umbraco.services").factory("latestsPostsService", function ($http) {  
        return {
            getAll : function(){
                return $http.get("/umbraco/backoffice/api/LatestPostsDashboard/GetLatestsPost");
            }
        };
    });