import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    NgIf,
    NgForOf,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  hide!: boolean;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  possuiErros(campo: string): boolean {
    return !!(
      this.loginForm.get(campo)?.touched || this.loginForm.get(campo)?.dirty
    );
  }

  obterErrosPorCampo(campo: string): string[] {
    const inputForm = this.loginForm.get(campo);
    const error: string[] = [];

    if (inputForm?.errors) {
      for (const errorKey in inputForm.errors) {
        if (errorKey === 'required') {
          error.push('Campo obrigatório');
        } else if (errorKey === 'minlength') {
          error.push(
            `${campo} deve ter pelo menos ${inputForm.errors['minlength'].requiredLength} caracteres`,
          );
        } else if (errorKey === 'email') {
          error.push(`email deve ser válido`);
        }
      }
    }

    return error;
  }
}
