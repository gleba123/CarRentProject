using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Ver6.ClassModels.PropInfos;
using DLL_Ver6.TableModels;

namespace DLL_Ver6.MainClass
{
  public  class UserClass
    {
        CarProjectContext db = new CarProjectContext(); //New object that connect the Web with the DB

        #region GetFunction's
        //Get All the cars using Linq to Connect 2 Tables to get spacific colum's:
        public IEnumerable<CarInformation> GetAllCars()
        {
            var Cars = (from Ctype in db.CarTypes
                        join Cinfo in db.CarInfos
                        on Ctype.CarNum equals Cinfo.CarNum
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
            return Cars;
        }

        //Get Car by spacific lisance:
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

        }

        //Get OrderBy Order Id
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
        }

        public RespModel ShowUserOrder(int userTz)
        {
            RespModel resp = new RespModel();
            var orders = db.RentTables.Where(orders => orders.UserTz == userTz);

            if (orders != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = orders;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }
        #endregion

        #region login & Register Functions
        public RespModel LogIn(string nickName, string password)
        {
            RespModel resp = new RespModel();
            UserTable login = db.UserTables.FirstOrDefault(log => log.NickName == nickName && log.Password == password);
            if (login != null)
            {
                resp.IsSuccess = true;
                resp.RespObject = login;
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }

        //Post Function For Register
        public RespModel Register(UserTable NewUser)
        {
            RespModel respModel = new RespModel();

            UserTable newUser = db.UserTables.FirstOrDefault(user => user.NickName == NewUser.NickName);

            try
            {
                if (newUser!=null)
                {
                    respModel.IsSuccess = false;
                    respModel.error = "user is already exist";

                }
                else
                {
                db.UserTables.Add(NewUser);
                db.SaveChanges();
                respModel.IsSuccess = true;

                }
            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;
            }
            return respModel;
        }

        public RespModel setImgeToDB(string nickName, string dbPath)
        {
            RespModel resp = new RespModel();
            UserTable userImage = db.UserTables.FirstOrDefault(r => r.NickName == nickName);
            if (userImage != null)
            {
                userImage.Picture = dbPath;
                db.SaveChanges();
                resp.IsSuccess = true;
                resp.RespObject = "image upload";
            }
            else
            {
                resp.IsSuccess = false;
            }
            return resp;
        }
        #endregion

        #region PostNewOrder
        //Post Function For Order
        public RespModel PostUserOrder(RentTable Order)
        {
            RespModel respModel = new RespModel();
            try
            {
                CarInfo car = db.CarInfos.FirstOrDefault(car => car.CarNum == Order.CarNum);
                if (car.Available == "no")
                {
                respModel.IsSuccess = false;
                respModel.error ="Error Car Is Already Taken";
                 return respModel;

                }
                else
                {
                db.RentTables.Add(Order);
                car.Available = CarStatus.no.ToString();
                db.SaveChanges();
                respModel.IsSuccess = true;


                }

            }
            catch (Exception ex)
            {
                respModel.IsSuccess = false;
                respModel.error = ex.Message;
            }
            return respModel;
        } //Post Function for new Order
        #endregion



    }
}
