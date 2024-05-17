pipeline {
    agent any

    environment {
    // CREDENTIALS_ID = "The-Key-Name"
    // GIT_BRANCH = "master"
    // GIT_SOURCE = "git@.../nihonto-genesis.git"
    // GIT_TARGET = "git@.../nihonto-publish-production.git"
    // REPO_PATH = "repo"
    // SOURCE_PATH = "source"
    // TARGET_PATH = "target"
    // PUBLISH_PATH = "$WORKSPACE/$TARGET_PATH/published"
    // STORE_PUBLISH_PATH = "$PUBLISH_PATH/Nihonto.Web.Store"
}

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        // stage('Build') {
        //     steps {
        //         script {
        //             // Restoring dependencies
        //             //bat "cd ${DOTNET_CLI_HOME} && dotnet restore"
        //             // sh "dotnet restore"

        //             // Building the application
        //             sh "dotnet publish /p:PublishProfile=DefaultContainer"
        //         }
        //     }
        // }

        // stage('Test') {
        //     steps {
        //         script {
        //             // Running tests
        //             sh "dotnet test --no-restore --configuration Release"
        //         }
        //     }
        // }

        stage('Publish') {
            steps {
                script {
                    // Publishing the application
                    sh "dotnet publish /p:PublishProfile=DefaultContainer"
                }
            }
        }
        stage('start') {
            steps {
                script {
                    she "podman run --rm -p 8080:8080 my_portfolio"

                }
            }
        }
    }

    post {
        success {
            echo 'Build, test, and publish successful!'
        }
    }
}