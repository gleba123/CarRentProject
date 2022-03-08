export class OrdersInfo {
  public constructor(
    public userTz?:number,
    public carNum?: number,
    public startRentDate?: string,
    public returnDate?: string,
    public realReturnDate?: string,
    public orderNum?: string,
  
  ) { }
}