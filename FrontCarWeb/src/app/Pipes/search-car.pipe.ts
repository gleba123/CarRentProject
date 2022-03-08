import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchCarPipe'
})
export class SearchPipePipe implements PipeTransform {

      // pipe to show spacific object in this case by manufactor

  transform(CarTypes:any[],character:any):any[] {
    if(character===undefined){
      return CarTypes;
    }
    else{ 
      return CarTypes.filter(function(type){
        return type.manufactor.toLowerCase().includes(character.toLowerCase());

    
        
})
  }

  }
}
