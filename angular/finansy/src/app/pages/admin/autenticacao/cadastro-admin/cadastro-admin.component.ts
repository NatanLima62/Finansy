import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdministracaoService } from '../../services/administracao.service';
import { CadastrarViewModel } from '../../models/administrador';

@Component({
  selector: 'app-cadastro-admin',
  templateUrl: './cadastro-admin.component.html',
  styleUrl: './cadastro-admin.component.scss',
})
export class CadastroAdminComponent implements OnInit {
  cadastroAdmForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private administracaoService: AdministracaoService,
  ) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.cadastroAdmForm = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
      telefone: ['', Validators.required],
      cpf: ['', Validators.required],
    });
  }

  cadastrar() {
    this.handleCadastrar();
  }

  async handleCadastrar() {
    const admin: CadastrarViewModel = {
      nome: this.cadastroAdmForm.get('nome')?.value,
      email: this.cadastroAdmForm.get('email')?.value,
      senha: this.cadastroAdmForm.get('senha')?.value,
      telefone: this.cadastroAdmForm.get('telefone')?.value,
      cpf: this.cadastroAdmForm.get('cpf')?.value,
    };

    await this.administracaoService.cadastrarAdmin(admin).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      },
    );
  }
}
