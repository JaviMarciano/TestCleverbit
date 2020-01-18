import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import IUser from '../../domain/user-credential';
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  loginInProcess = false;
  emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  submitted: boolean;
  invalidLogin: boolean;
  invalidLoginMessage: string;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      email: ["", Validators.required],
      password: ["", Validators.required]
    });
  }


  get f() {
    return this.form.controls;
  }

  login() {
    this.loginInProcess = true;
    this.submitted = true;

    if (this.form.invalid) {
      this.loginInProcess = false;
      return;
    }
    var user = <IUser>this.form.value;
    this.authService
      .login(user)
      .then(loginResult => {
        if (loginResult) {
          this.invalidLogin = false;
          this.authService.user = loginResult;
          this.router.navigateByUrl(`/game`);
        } else {
          this.invalidLogin = true;
          this.loginInProcess = false;
        }
      })
      .catch(x => {
        console.log(x.error[0]);
        this.invalidLoginMessage = "Invalid credentials.";
        this.invalidLogin = true;
      });
  }
}
