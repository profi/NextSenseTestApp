import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class UserService {
  appurl: string = "";
  constructor(private httpobj: HttpClient, @Inject('BASE_URL') _baseurl: string) {
    this.appurl = _baseurl;
  }

  getAllUsers(): Observable<UserDataModel> {
    return this.httpobj.get<UserDataModel>(this.appurl + "api/values/GetAllUsers")
  }




}


export class UserDataModel {
  id: number;
  firstName: string;
  lastName : string;
  email: string;
  city: string;
  address: string;
}
