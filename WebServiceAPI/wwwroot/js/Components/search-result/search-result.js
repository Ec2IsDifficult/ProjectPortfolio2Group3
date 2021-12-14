define(["knockout", "pubsub", "dataservice", "viewmodel"], function(ko, Ps, ds, vm){
    return function(params){
        let searchResultList = ko.observable("search-result-list");
        let searchField = ko.observable();
        
        let searchButton = () => {
            ds.searchTitles(data => {
                if(data) {
                    
                    vm.changeContent(vm.componentItems.find(item => item.component === "search-result-list"));
                    vm.currentParams(data)

                }
            } ,searchField());
        }
        return {
            searchResultList:searchResultList,
            searchButton:searchButton,
            searchField:searchField
        }
    
    }
});