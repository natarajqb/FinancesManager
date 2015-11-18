var app = angular.module('myApp', []);
app.controller('listCtrl', function($scope, $http) {

	$scope.GetExpenses = function(){
    $http.get("http://localhost:2587/api/expenses")
    .success(function(response) {$scope.expenses = response;}).error(function(response){
        alert("Error in getting expense list. Please try again!")
    });
    }
    
    
    $scope.AddExpense = function() {  
    
       
    var data = JSON.stringify({Title:$scope.title,Amount:$scope.amount,Date:$scope.date});
    $http({
    method: 'POST',
    url: 'http://localhost:2587/api/expenses',    
    data: data,
    headers: {'Content-Type': 'application/JSON'}})
    .success(function () {	
                   $scope.GetExpenses();
                   $scope.title=null;   
                   $scope.amount=null;   
                   $scope.date=null;                    
                })
                .error(function () {                 
                });
                
    }


    

$scope.selected_expenses = [];
    $scope.AddToArray=function(expense){
        
            var index = $scope.selected_expenses.indexOf(expense.ExpenseId);
            if(index == -1 && expense.selected)
            {
                $scope.selected_expenses.push(expense.ExpenseId);                
            } 
            else if (!expense.selected && index != -1)
            {
                $scope.selected_expenses.splice(expense.ExpenseId, 1);                 
            }
    }

    $scope.DeleteEntry = function(){
        if($scope.selected_expenses.length>0)
        {
           if(confirm('Are you sure you want to delete the value(s)?')==true)
           {
                for(var i in $scope.selected_expenses)
                {   
                    $http.delete('http://localhost:2587/api/expenses/'+ parseInt($scope.selected_expenses[i]))
                    .success(function (data) 
                    {   
                        $scope.ServerResponse = data;                
                        $scope.GetExpenses();
                    });
                }     
            }            
        }        
    }

     
});

