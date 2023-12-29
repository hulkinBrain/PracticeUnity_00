pipeline {
    agent any
    environment {
        UNITY_PATH = "\"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe\""
        PATH_TO_7Z = "\"C:/Program Files/7-Zip/7z\""
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
                    def pipeline_name = allJob[0];
                    def branch_hierarchy = env.JOB_NAME.substring(allJob[0].length()+1, env.JOB_NAME.length());
                    env.PATH_TO_BUILD_FOLDER = "${JENKINS_HOME}/jobs/" + pipeline_name + "/branches/" + branch_hierarchy + "/builds/${BUILD_NUMBER}";
                    
                }
                bat "${UNITY_PATH} -nographics -batchmode -quit -executeMethod JenkinsBuild.BuildDefault ${JOB_NAME} ${PATH_TO_BUILD_FOLDER}/output"
            }
        }
        stage('TEST') {
            environment {
                BALLMOVELOG_FILENAME = "BallMoveLog.txt"
            }
            steps {
                bat "\"${PATH_TO_BUILD_FOLDER}/output/${JOB_NAME}.exe\" -nographics -batchmode -logMode \"${PATH_TO_BUILD_FOLDER}/output/${BALLMOVELOG_FILENAME}\""
            }
        }
        stage('PACKAGE') {
            environment {
                PATH_TO_ARCHIVE_FOLDER = "${PATH_TO_BUILD_FOLDER}/archive"
            }
            steps {
                script {
                    env.DATE = new Date().format("yyyy_MM_dd");
                }
                // Create the archive folder in the job to hold the build artifact
                bat "MKDIR \"${PATH_TO_ARCHIVE_FOLDER}\""
                // Zip build output directory and place in job archive
                bat "${PATH_TO_7Z} a \"${PATH_TO_ARCHIVE_FOLDER}/${DATE}_${BUILD_TAG}.zip\" \"${PATH_TO_BUILD_FOLDER}/output\""
            }
        }
        stage('CLEANUP') {
            steps {
                // Delete "output" folder
                bat "RMDIR ${PATH_TO_BUILD_FOLDER}/output /Q"
            }
        }
    }
}