using DLL_Ver6.ClassModels.PropInfos;
using DLL_Ver6.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.MainClass
{
  public  class ManagerClass
    {
        CarProjectContext db = new CarProjectContext(); //New object that connect the Web with the DB

        #region GeneralGet
        public RespModel GetAllUsers()
        {
            RespModel resp = new RespModel();
            resp.RespObject = db.UserTables;
            if (resp != null)
            {
                resp.IsSuccess = true;
                

            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        } //Get Function of all User's
        public IEnumerable<CarInformation> GetAllCars()
        {
            var Cars = (from Ctype in db.CarTypes
                        join Cinfo in db.CarInfos
                        on Ctype.CarNum equals Cinfo.CarNum
                        select new CarInformation()
                        {
                            CarId = Ctype.CarId,
                            quantity = Ctype.Quantity,
                            carNumber = Cinfo.CarNum,
                            manufactor = Ctype.Manufactor,
                            model = Ctype.Model,
                            km = Cinfo.Km,
                            year = Ctype.Year,
                            dayPrice = Ctype.Dprice,
                            delayPrice = Ctype.DelayPrice,
                            available = Cinfo.Available,
                            rentable = Cinfo.Rentable,
                            picture = Cinfo.Pic
                        }).ToList();
            return Cars;
        } //Get Function for all Cars

        public RespModel GetAllOrders()
        {
            RespModel resp = new RespModel();
            resp.RespObject = db.RentTables;
            if (resp != null)
            {
                resp.IsSuccess = true;

            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        } //Get Function for all Order's

        #endregion

        #region GetById/Tz
        public RespModel GetUserByTz(int UserTz)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(user => user.UserTz == UserTz);
            if (ExistingUser != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = ExistingUser;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;

        } //Get Spacific User Function by Id/Tz  

        public RespModel GetOrderById(int OrderId)
        {
            RespModel resp = new RespModel();
            RentTable ExistingOrder = db.RentTables.FirstOrDefault(order => order.OrderNum == OrderId);
            if (ExistingOrder != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = ExistingOrder;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }   //Get Spacific Order By id

        public IEnumerable<CarInformation> GetCarsByNumber(int carNum)
        {
            var CarsByNum = (from Ctype in db.CarTypes
                             join Cinfo in db.CarInfos on Ctype.CarNum equals Cinfo.CarNum
                             where Cinfo.CarNum == carNum
                             select new CarInformation()
                             {
                                 carNumber = Cinfo.CarNum,
                                 manufactor = Ctype.Manufactor,
                                 model = Ctype.Model,
                                 km = Cinfo.Km,
                                 year = Ctype.Year,
                                 dayPrice = Ctype.Dprice,
                                 delayPrice = Ctype.DelayPrice,
                                 available = Cinfo.Available,
                                 rentable = Cinfo.Rentable,
                                 picture = Cinfo.Pic
                             }).ToList();
            return CarsByNum;

        } //get car by number
        #endregion

        #region PostFunction
        public RespModel PostNewUser(UserTable NewUser)
        {
            RespModel respModel = new RespModel();
            try
            {

                db.UserTables.Add(NewUser);
                db.SaveChanges();
                respModel.IsSuccess = true;

            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;
            }
            return respModel;
        }


        public RespModel PostCarTypeTable(CarType cType) //Post Function For The CarType Table
        {
            RespModel resp = new RespModel();

            try
            {
                db.CarTypes.Add(cType);
                db.SaveChanges();
                resp.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;
            }
            return resp;
        }

        public RespModel PostCarInfoTable(CarInfo cInfo) //Post Function For The CarInfo Table
        {
            RespModel resp = new RespModel();
            try
            {

                db.CarInfos.Add(cInfo);
                db.SaveChanges();
                resp.IsSuccess = true;

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;
            }
            return resp;
        }

        public RespModel PostUserOrder(RentTable Order)
        {
            RespModel respModel = new RespModel();
            try
            {

                db.RentTables.Add(Order);
                db.SaveChanges();
                respModel.IsSuccess = true;

            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;

            }
            return respModel;
        }


        #endregion

        #region Put Functions

        public RespModel UpdateUserInfo(int userTz, UserTable UserToUpdate)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(user => user.UserTz == userTz);
            if (UserToUpdate.UserTz != 0)
            {

            ExistingUser.UserTz = UserToUpdate.UserTz;
            }
            if (UserToUpdate.Bday!=null)
            {
            ExistingUser.Bday = UserToUpdate.Bday;
            }
            if (UserToUpdate.Email!=null)
            {
            ExistingUser.Email = UserToUpdate.Email;
            }
            if (UserToUpdate.FullName!=null)
            {
            ExistingUser.FullName = UserToUpdate.FullName;

            }
            if (UserToUpdate.Gender!=null)
            {

            ExistingUser.Gender = UserToUpdate.Gender;
            }
            if (UserToUpdate.Role!=null)
            {
            ExistingUser.Role = UserToUpdate.Role;

            }
            if (UserToUpdate.NickName!=null)
            {
            ExistingUser.NickName = UserToUpdate.NickName;
            }
            if (UserToUpdate.Password!=null)
            {
            ExistingUser.Password = UserToUpdate.Password;
            }
            if (UserToUpdate.Picture!=null)
            {
            ExistingUser.Picture = UserToUpdate.Picture;
            }
            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingUser;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //Put Function For Existing User

        public RespModel UpdateOrderInfo(int orderNum, RentTable OrderToUpdate)
        {
            RespModel resp = new RespModel();
            RentTable ExistingOrder = db.RentTables.FirstOrDefault(order => order.OrderNum == orderNum);
            if (OrderToUpdate.ReturnDate != null)
            {
            ExistingOrder.ReturnDate = OrderToUpdate.ReturnDate;
            }
            if (OrderToUpdate.RealReturnDate != null)
            {
            ExistingOrder.RealReturnDate = OrderToUpdate.RealReturnDate;
            }
            if (OrderToUpdate.StartRentDate != null)
            {
            ExistingOrder.StartRentDate = OrderToUpdate.StartRentDate;
            }
            if (OrderToUpdate.CarNum.ToString()!=null)
            {
                ExistingOrder.CarNum = OrderToUpdate.CarNum;
            }
            if (OrderToUpdate.UserTz!=0)
            {
                ExistingOrder.UserTz = OrderToUpdate.UserTz;
            }
            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingOrder;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //Put Function For Existing Order

        public RespModel UpdateCarsInfo(int carNum, CarInfo cInfoToUpdate)
        {
            RespModel resp = new RespModel();
            CarInfo ExistingCInfo = db.CarInfos.FirstOrDefault(car => car.CarNum == carNum);
            if (cInfoToUpdate.CarType!=null)
            {
            ExistingCInfo.CarType = cInfoToUpdate.CarType;
            }
            if (cInfoToUpdate.Km!=0)
            {
            ExistingCInfo.Km = cInfoToUpdate.Km;
            }
            if (cInfoToUpdate.Pic!=null)
            {
            ExistingCInfo.Pic = cInfoToUpdate.Pic;
            }
            if (cInfoToUpdate.Rentable!=null)
            {
            ExistingCInfo.Rentable = cInfoToUpdate.Rentable;
            }
            if (cInfoToUpdate.Available!=null)
            {
            ExistingCInfo.Available = cInfoToUpdate.Available;
            }
            if (cInfoToUpdate.CarNum.ToString()!=null)
            {
            ExistingCInfo.CarNum = cInfoToUpdate.CarNum;
            }

            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingCInfo;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //Put Function For Existing CarInfoTable

        public RespModel UpdateCarsType(int carNum, CarType cTypeToUpdate)
        {
            RespModel resp = new RespModel();
            CarType ExistingCtype = db.CarTypes.FirstOrDefault(car => car.CarNum == carNum);
            if (cTypeToUpdate.CarNum.ToString()!=null)
            {
            ExistingCtype.CarNum = cTypeToUpdate.CarNum;
            }
            if (cTypeToUpdate.Quantity!=0)
            {
                ExistingCtype.Quantity = cTypeToUpdate.Quantity;
            }
            if (cTypeToUpdate.Manufactor!=null)
            {
            ExistingCtype.Manufactor = cTypeToUpdate.Manufactor;
            }
            if (cTypeToUpdate.Model!=null)
            {
            ExistingCtype.Model = cTypeToUpdate.Model;
            }
            if (cTypeToUpdate.Dprice!=0)
            {
            ExistingCtype.Dprice = cTypeToUpdate.Dprice;
            }
            if (cTypeToUpdate.DelayPrice!=0)
            {
            ExistingCtype.DelayPrice = cTypeToUpdate.DelayPrice;
            }
            if (cTypeToUpdate.Year!=0)
            {
            ExistingCtype.Year = cTypeToUpdate.Year;
            }

            try
            {
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = ExistingCtype;
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;

            }
            return resp;

        } //Put Function For Existing CarInfoTable





        #endregion

        #region Delete Function

        public RespModel DeleteUser(int userTz)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(delete => delete.UserTz == userTz);


            try
            {
                if (ExistingUser != null)
                {
                    db.Remove(ExistingUser);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;



        }

        public RespModel DeleteOrder(int orderNum)
        {
            RespModel resp = new RespModel();
            RentTable ExistingOrder = db.RentTables.FirstOrDefault(delete => delete.OrderNum == orderNum);

            try
            {
                if (ExistingOrder != null)
                {
                    db.Remove(ExistingOrder);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;


        }
        public RespModel DeleteCarType(int CarTypeNum)
        {
            RespModel resp = new RespModel();
            CarType ExistingCarType = db.CarTypes.FirstOrDefault(delete => delete.CarNum == CarTypeNum);

            try
            {
                if (ExistingCarType != null)
                {
                    db.Remove(ExistingCarType);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;


        }
        public RespModel DeleteCarInfo(int CarNumInfo)
        {
            RespModel resp = new RespModel();
            CarInfo ExistingCarNumIfo = db.CarInfos.FirstOrDefault(delete => delete.CarNum == CarNumInfo);

            try
            {
                if (ExistingCarNumIfo != null)
                {
                    db.Remove(ExistingCarNumIfo);
                    db.SaveChanges();
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.error = ex.Message;


            }
            return resp;


        }

        #endregion


    }
}
