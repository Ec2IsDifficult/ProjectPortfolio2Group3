define(["knockout", "dataservice", "viewmodel"], function(ko, ds, vm) {
    return function(params) {
        
        let randPeople = ko.observableArray([]);
        let args = Object.values(params).splice(1)
        params.func(data => randPeople(data), ...args);
        let goToSpecificPerson = (nconst) => {
            vm.changeContent(vm.componentItems.find(item => item.component === "person-page"));
            vm.currentParams(nconst);

        }
        return {
            randPeople: randPeople,goToSpecificPerson:goToSpecificPerson
        }
    }
});