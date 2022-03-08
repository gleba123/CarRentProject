using DLL_Ver6.ClassModels.PropInfos;
using DLL_Ver6.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Ver6.MainClass
{
   public class EmployeeClass
    {
        //conection with the db - object from the webApi
        CarProjectContext db = new CarProjectContext(); //New object that connect the Web with the DB

        #region GetFunction's
        //get func that connect 2 tables to show in ones all the info by Linq 
        public IEnumerable<CarInformation> GetAllCars() //Get Function for all Cars
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

        //get all Orders Function connect with the controller
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
        } //Get Function of all Orer's

        //get car by id Function connect with the controller , works with ling in this table give us the option to show all the info of 2 tables in 1

        public IEnumerable<CarInformation> GetCarsByNumber(int carNum)
        {
            RespModel resp = new RespModel();

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

        //Show user spacific orders
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


        //Get Function - Show's Spacific User
        public RespModel GetUserById(int Userid)
        {
            RespModel resp = new RespModel();
            UserTable ExistingUser = db.UserTables.FirstOrDefault(user => user.UserId == Userid);
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

        }

        #endregion

        #region PutFunction

        //give the Emp the option to Return The Car
        public RespModel EmployeeReturnCar(int carnum, RentTable RRD)
        {
            RespModel resp = new RespModel();
            CarInfo info = db.CarInfos.FirstOrDefault(carNum => carNum.CarNum == carnum);
            RentTable Rent = db.RentTables.FirstOrDefault(carNum => carNum.CarNum == carnum);
            if (info.Available == "no")
            {
                info.Available = CarStatus.yes.ToString();
                Rent.RealReturnDate = RRD.RealReturnDate;
                db.SaveChanges();
                resp.IsSuccess = true;
            }
   
            else
            {

                resp.IsSuccess = false;
            }

            return resp;

        } //put Func that allow us to update the RealReturnDate + the Availability of the car
        #endregion
    }
}
