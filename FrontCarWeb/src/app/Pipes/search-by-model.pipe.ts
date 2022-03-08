import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchByModel'
})
export class SearchByModelPipe implements PipeTransform {

  // pipe to show spacific object in this case by model
  transform(CarTypes:any[],character:any):any[] {
    if(character===undefined){
      return CarTypes;
    }
    else{ 
      return CarTypes.filter(function(type){
        return type.model.toLowerCase().includes(character.toLowerCase());

    
        
})
  }

  }
}
