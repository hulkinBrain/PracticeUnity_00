pipeline {
    agent any
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe"
    }
    options {
        timestamps()
        timeout(time: 5, unit: 'MINUTES')
    }
    stages {
        stage('BUILD') {
            steps {
                script {
                    // Splitting Pipeline name and directory path/hierarchy for putting the unity build in the correct path 
                    def allJob = env.JOB_NAME.tokenize('/') as String[];
                    env.PIPELINE_NAME = allJob[0];
                    env.BRANCH_HIERARCHY = env.JOB_NAME.substring(allJob[0].length()+1, env.JOB_NAME.length());
                    env.PATH_TO_BUILD_FOLDER = "${JENKINS_HOME}/jobs/${PIPELINE_NAME}/branches/${BRANCH_HIERARCHY}/builds/${BUILD_NUMBER}";
                    
                }
                bat "\"${UNITY_PATH}\" -nographics -batchmode -quit -executeMethod JenkinsBuild.BuildDefault ${JOB_NAME} ${PATH_TO_BUILD_FOLDER}/output"
            }
        }
        stage('TEST') {
            environment {
                BALLMOVELOG_FILENAME = "BallMoveLog.txt"
            }
            steps {
                bat "\"${JENKINS_HOME}/jobs/${PIPELINE_NAME}/branches/${BRANCH_HIERARCHY}/builds/${BUILD_NUMBER}/output/${JOB_NAME}.exe\" -nographics -batchmode -logMode \"${PATH_TO_BUILD_FOLDER}/output/${BALLMOVELOG_FILENAME}\""
            }
        }
        stage('PACKAGE') {
            environment {
                PATH_TO_ARCHIVE_FOLDER = "${PATH_TO_BUILD_FOLDER}/archive"
            }
            steps {
                // Create the archive folder in the job to hold the build artifact
                bat "MKDIR ${PATH_TO_ARCHIVE_FOLDER}"
                // Zip build output directory and place in job archive
                bat "\"C:/Program Files/7-Zip/7z\" a \"${PATH_TO_ARCHIVE_FOLDER}/${BUILD_TAG}.zip\" \"${PATH_TO_BUILD_FOLDER}/output\""
            }
        }
    }
}