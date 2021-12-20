define(["knockout", "viewmodel", "viewmodel"], function(ko, vm){
    return function(params) {
        let results = ko.observableArray(params);
        console.log(results())

        let goToSpecificTitle = (tconst) => {
            vm.changeContent(vm.componentItems.find(item => item.component === "titles-page"));
            vm.currentParams(tconst);

        }
        return {
            results,
            goToSpecificTitle:goToSpecificTitle
        }
    }    
});