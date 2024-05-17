pipeline {
    agent any

   environment {
        DOTNET_CLI_HOME = "/usr/local/dotnet"
        PATH = "${env.DOTNET_CLI_HOME}:${env.PATH}"
    }


    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                script {
                    // Restoring dependencies
                    //bat "cd ${DOTNET_CLI_HOME} && dotnet restore"
                    sh "dotnet restore"

                    // Building the application
                    sh "dotnet build --configuration Release"
                }
            }
        }

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
                    sh "podman run --rm -p 8080:8080 my_portfolio"
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