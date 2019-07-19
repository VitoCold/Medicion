import React from "react";
import { connect } from "react-redux";
import * as industriasActions from "../../redux/actions/industriasActions";
import PropTypes from "prop-types";
import { bindActionCreators } from "redux";
import { Redirect } from "react-router-dom";
// import { toast } from "react-toastify";
import IndustriaList from "./IndustriaList";
import PageNotFound from "../../PageNotFound";

class IndustriasPage extends React.Component {
  state = {
    redirectToAddIndustriaPage: false
  };
  componentDidMount() {
    const { industrias, actions } = this.props;
    if (industrias.length === 0) {
      actions.loadIndustrias().catch(error => {
        alert("Loading industrias failed" + error);
      });
    }
  }

  // handleDeleteCourse = async course => {
  //   toast.success("Course deleted");
  //   try {
  //     await this.props.actions.deleteCourse(course);
  //   } catch (error) {
  //     toast.error("Delete failed. " + error.message, { autoClose: false });
  //   }
  // };

  render() {
    return (
      <>
        {this.state.redirectToAddIndustriaPage && <Redirect to="/industria" />}
        <hr/>
        <h4 className="titulo">Industrias</h4>
        {this.props.loading ? (
          <PageNotFound />
        ) : (
          <>
            <IndustriaList
              industrias={this.props.industrias}
            />
          </>
        )}
      </>
    );
  }
}

IndustriasPage.propTypes = {
  industrias: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired,
  loading: PropTypes.bool.isRequired
};

function mapStateToProps(state) {
  return {
    industrias:state.industrias,
    loading: state.apiCallsInProgress > 0
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      loadIndustrias: bindActionCreators(industriasActions.loadIndustrias, dispatch)
    }
  };
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(IndustriasPage);