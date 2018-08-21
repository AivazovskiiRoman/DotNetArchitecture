import { Component } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { FormChildModel } from "./form.child.model";
import { FormModel } from "./form.model";

@Component({ selector: "app-form", templateUrl: "./form.component.html" })
export class FormComponent {
    disabled = false;
    form: FormGroup;
    model: FormModel;

    constructor(private readonly formBuilder: FormBuilder) {
        this.createForm();
        this.createModel();
    }

    createForm() {
        this.form = this.formBuilder.group({
            child: this.formBuilder.group({ string: [] }),
            number: [],
            string: []
        });
    }

    createModel() {
        this.model = new FormModel();
        this.model.child = new FormChildModel();
    }

    submit() { }
}
