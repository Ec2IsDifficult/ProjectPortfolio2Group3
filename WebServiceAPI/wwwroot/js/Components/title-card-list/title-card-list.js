define(["knockout", "dataservice"], function (ko, ds) {
   return function(params) {
       
       let randomTitles = ko.observableArray([]);
       
       ds.getRandomTitles(data => randomTitles(data),
           6, 8);
       return {
           randomTitles: randomTitles
       }
   }    
});