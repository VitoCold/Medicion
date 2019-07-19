import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { loadIndustrias } from "../../redux/actions/industriasActions";
import PropTypes from "prop-types";
// import { toast } from "react-toastify";

export function ManageIndustriasPage({
  industrias,
  loadIndustrias,
  ...props
}) {
  const [industria, setIndustria] = useState({ ...props.industria });
//   const [errors, setErrors] = useState({});
//   const [saving, setSaving] = useState(false);

  useEffect(() => {
    if (industrias.length === 0) {
      loadIndustrias().catch(error => {
        alert("Loading industrias failed" + error);
      });
    } else {
      setIndustria({ ...props.industria });
    }
  },[props.industria]);

//   function handleChange(event) {
//     const { name, value } = event.target;
//     setIndustria(prevIndustria => ({
//       ...prevIndustria,
//       [name]: name === "categoriaId" ? parseInt(value, 10) : value
//     }));
//   }

//   function formIsValid() {
//     const { title, categoriaId, category } = course;
//     const errors = {};

//     if (!title) errors.title = "Title is required.";
//     if (!authorId) errors.author = "Author is required";
//     if (!category) errors.category = "Category is required";

//     setErrors(errors);
//     // Form is valid if the errors object still has no properties
//     return Object.keys(errors).length === 0;
//   }

//   function handleSave(event) {
//     event.preventDefault();
//     if (!formIsValid()) return;
//     setSaving(true);
//     saveCourse(course)
//       .then(() => {
//         toast.success("Course saved.");
//         history.push("/courses");
//       })
//       .catch(error => {
//         setSaving(false);
//         setErrors({ onSave: error.message });
//       });
//   }

//   return industrias.length === 0 ? (
//     <Spinner />
//   ) : (
//     <CourseForm
//       course={course}
//       errors={errors}
//       authors={authors}
//       onChange={handleChange}
//       onSave={handleSave}
//       saving={saving}
//     />
//   );
}

ManageIndustriasPage.propTypes = {
  industrias: PropTypes.array.isRequired,
  loadIndustrias: PropTypes.func.isRequired,
  history: PropTypes.object.isRequired
};

export function getIndustriaByName(industrias, nombre) {
  return industrias.find(industria => industria.nombre === nombre) || null;
}

function mapStateToProps(state, ownProps) {
  const nombre = ownProps.match.params.nombre;
  const industria =
    nombre && state.industrias.length > 0
      ? getIndustriaByName(state.industrias, nombre)
      : newIndustria;
  return {
    industria,
    industrias: state.industrias
  };
}

const mapDispatchToProps = {
  loadIndustrias
};

const newIndustria =    {
    industriaId: "",
    tag: "",
    nombre: "",
    categoriaId: "",
    categoria: null,
    sedeId: "",
    sede: null,
    tuberiaId: 1,
    tuberia: null,
    elementos: null
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ManageIndustriasPage);