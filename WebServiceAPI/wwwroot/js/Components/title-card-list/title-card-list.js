define(["knockout", "dataservice"], function (ko, ds) {
   return function(params) {       
       let randomTitles = ko.observableArray([]);
       let args = Object.values(params).splice(1)
       params.func(data => {
           if (data.data)  
               randomTitles(data.data)
           else
               randomTitles(data)
       }, ...args);
       
       return {
           randomTitles: randomTitles
       }
   }    
});