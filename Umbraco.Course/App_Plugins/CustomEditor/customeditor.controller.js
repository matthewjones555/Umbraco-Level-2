angular.module("umbraco").controller("My.CustomEditorController", function ($scope, notificationsService) {
	$scope.limitChars = function () {
		var limit = $scope.model.config.limit;

		if ($scope.model.value.length > limit) {
			$scope.info = "You cannot write more than " + limit + " characters!";
			notificationsService.remove(0);
			notificationsService.warning($scope.info);
			$scope.model.value = $scope.model.value.substr(0, limit);
		} else {
			$scope.info = "You have " + (limit - $scope.model.value.length) + " characters left.";
		}
	}
});