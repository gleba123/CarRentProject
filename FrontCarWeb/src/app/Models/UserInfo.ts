export class UserProps {
  public constructor(
    public userId?:number,
    public nickName?: string,
    public password?: string,
    public userTz?: number,
    public fullName?: string,
    public bday?: string,
    public email?: string,
    public gender?: string,
    public role?: string,
    public picture?: string,
  ) { }
}